import React from "react";
import { Navigate, Route, Routes } from "react-router-dom";
import Login from "../pages/Login";
import Patient from "../pages/Patient";
import Doctor from "../pages/Doctor";
import Archive from "../pages/Archive";
import NotFound from "../pages/NotFound";
import AccessDenied from "../pages/AccessDenied";
import ForgotPassword from "../pages/ForgotPassword";
import PrivateRoute from "./PrivateRoute";

function RouterConfig() {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/girisyap" replace />} />
      <Route path="/girisyap" element={<Login />} />

      <Route
        path="/hasta/:userId"
        element={
          <PrivateRoute allowedRoles={["Hasta"]}>
            <Patient />
          </PrivateRoute>
        }
      />
      <Route
        path="/doktor/:userId"
        element={
          <PrivateRoute allowedRoles={["Doktor"]}>
            <Doctor />
          </PrivateRoute>
        }
      />
      <Route
        path="/arsiv/:doctorId"
        element={
          <PrivateRoute allowedRoles={["Doktor"]}>
            <Archive />
          </PrivateRoute>
        }
      />

      <Route path="/sifremiunuttum" element={<ForgotPassword />} />

      <Route path="/yetkisiz-erisim" element={<AccessDenied />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}

export default RouterConfig;
