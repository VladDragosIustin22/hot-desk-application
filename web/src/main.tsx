import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import SignUp from "./components/sign-up-page";
import Header from "./components/main-screen";
import LogIn from "./components/login-page";
import ReserveDesk from "./components/reserve-a-desk";
import ReservationOverview from "./components/reservation-overview";

import EditReservation from "./components/edit-reservation";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/SignUp",
    element: <SignUp />,
  },
  {
    path: "/login-page",
    element: <LogIn />,
  },
  {
    path: "/main-screen",
    element: <Header />,
  },
  {
    path: "/reserve-a-desk",
    element: <ReserveDesk />,
  },
  {
    path: "/ReservationOverview",
    element: <ReservationOverview />,
  },

  {
    path: "/EditReservation",
    element: <EditReservation />,
  },
]);

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
