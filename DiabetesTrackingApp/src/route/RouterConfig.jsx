import React from "react";
import { Navigate, Route, Routes } from "react-router-dom";
import Login from "../pages/Login";
import Patient from "../pages/Patient";
import Doctor from "../pages/Doctor";
import Archive from "../pages/Archive";
import ForgotPassword from "../pages/ForgotPassword";

function RouterConfig() {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/girisyap" replace />} />
      <Route path="/girisyap" element={<Login />} />

      <Route path="/hasta/:userId" element={<Patient />} />
      <Route path="/doktor/:userId" element={<Doctor />} />
      <Route path="/arsiv/:doctorId" element={<Archive />} />

      <Route path="/sifremiunuttum" element={<ForgotPassword />} />
    </Routes>
  );
}

export default RouterConfig;
