import React from "react";
import { Route, BrowserRouter } from "react-router-dom";

import Home from "./pages/Home";
import CrearePoint from "./pages/CreatePoint";

const Routes = () => {
  return (
    <BrowserRouter>
      <Route component={Home} path="/" exact />
      <Route component={CrearePoint} path="/create-point" />
    </BrowserRouter>
  );
};

export default Routes;
