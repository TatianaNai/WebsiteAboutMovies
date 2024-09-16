namespace PortalAboutEverything.Data.Enums
{
    [Flags]
    public enum Permission
    {
        None = 0,
        CanViewPremission = 1,
        CanEditPremission = 2,
        CanCreateMovie = 4,
        CanDeleteMovie = 8,
        CanUpdateMovie = 16,
        CanLeaveReviewForMovie = 32,
    }
}