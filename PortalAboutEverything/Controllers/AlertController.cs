﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PortalAboutEverything.Data.Repositories.Interfaces;
using PortalAboutEverything.Hubs;
using PortalAboutEverything.Mappers;
using PortalAboutEverything.Models.Alert;
using PortalAboutEverything.Services;

namespace PortalAboutEverything.Controllers
{
    public class AlertController : Controller
    {
        private IAlertRepository _alertRepository;
        private AlertMapper _alertMapper;
        public IHubContext<AlertHub, IAlertHub> _alertHub;

        public AlertController(IAlertRepository alertRepository,
            AlertMapper alertMapper,
            IHubContext<AlertHub, IAlertHub> alertHub)
        {
            _alertRepository = alertRepository;
            _alertMapper = alertMapper;
            _alertHub = alertHub;
        }

        public IActionResult Index()
        {
            var alerts = _alertRepository.GetAll();
            var alertViewModels = new List<AlertIndexViewModel>();

            foreach (var alert in alerts)
            {
                var alertViewModel = _alertMapper.MapToIndex(alert);
                alertViewModels.Add(alertViewModel);
            }

            return View(alertViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlertCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var alert = _alertMapper.MapToDataBaseModel(viewModel);
            _alertRepository.Create(alert);

            await _alertHub.Clients.All.AlertWasCreatedAsync(alert.Id, alert.Text);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _alertRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
