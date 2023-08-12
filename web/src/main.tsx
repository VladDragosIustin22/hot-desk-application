import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import SignUp from "./components/sign-up-page";
import LogIn from "./components/login-page";
import ReserveDesk from "./components/reserve-a-desk";
import ReservationOverview from "./components/reservation-overview";
import Settings from "./components/settings";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/signup",
    element: <SignUp />,
  },
  {
    path: "/login",
    element: <LogIn />,
  },
  {
    path: "/reserve-a-desk",
    element: <ReserveDesk />,
  },
  {
    path: "/reservationoverview",
    element: <ReservationOverview />,
  },
  {
    path: "/settings",
    element: <Settings />,
  },
]);

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
