import React from "react";

import { Link } from "react-router-dom";

function NavBar() {
    return (
        <nav className="navbar navbar-expand-sm bg-5">
            <div className="container-fluid">
                <div
                    className="collapse navbar-collapse"
                   
                >
                    <ul className="navbar-nav me-auto mb-lg-0">
                        <li className="nav-item">
                            <Link to="/" className="nav-link active">
                                Productos
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/stocks" className="nav-link active">
                                Stock
                            </Link>
                        </li>
                        
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default NavBar;
