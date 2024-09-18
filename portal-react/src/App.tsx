import './App.css';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import { Home, Login } from './components/pages';
import { CreateMovie, MovieDetails, Movies } from './components/pages/movies';
import AuthContext from './contexts/AuthContext';
import UpdateMovie from './components/pages/movies/UpdateMovie';

function App() {
    return (
        <div className="App">
            <AuthContext>
                <BrowserRouter>
                    <div>
                        <Link to="/">Home</Link>
                        <Link to="/login">Login</Link>
                        <Link to="/movies">Movies</Link>
                    </div>
                    <div className="content">
                        <Routes>
                            <Route path="" Component={Home}></Route>
                            <Route path="/login" Component={Login}></Route>
                            
                            <Route path="/movies">
                                <Route path="" Component={Movies}></Route>
                                <Route
                                    path=":id"
                                    Component={MovieDetails}
                                ></Route>
                                <Route
                                    path="create"
                                    Component={CreateMovie}
                                ></Route>
                            </Route>
                            <Route path="/movies/update">
                                <Route
                                    path=":movieId"
                                    Component={UpdateMovie}
                                ></Route>
                            </Route>
                        </Routes>
                    </div>
                </BrowserRouter>
            </AuthContext>
        </div>
    );
}

export default App;
