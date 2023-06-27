import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import SignUp from "./components/sign-up-page";
import Header from "./components/main-screen";

const router = createBrowserRouter([
  {
    path: "/sign-up-page",
    element: <SignUp />,
  },
  {
    path: "main-screen",
    element: <Header />,
  }
]);

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
