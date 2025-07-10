import React from "react";
import { Navigate } from "react-router-dom";

function PrivateRoute({ children, allowedRoles }) {
  try {
    const role = localStorage.getItem("Role");

    // Rol uygun mu?
    if (allowedRoles.includes(role)) {
      return children;
    } else {
      // Rol uygun değil → yetkisiz sayfa mesela veya anasayfa
      return <Navigate to="/yetkisiz-erisim" replace />;
    }
  } catch (error) {
    console.error("Token çözümleme hatası:", error);
    return <Navigate to="/yetkisiz-erisim" replace />;
  }
}

export default PrivateRoute;
