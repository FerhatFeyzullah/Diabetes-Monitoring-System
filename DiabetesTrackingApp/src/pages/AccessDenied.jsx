import { Button } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";

function AccessDenied() {
  const navigate = useNavigate();
  return (
    <div className="access-denied-main-div">
      <div className="flex-column">
        <div style={{ marginTop: "30px" }}>
          <Button
            variant="contained"
            color="warning"
            onClick={() => navigate("/girisyap")}
          >
            Giriş Ekranına Dön
          </Button>
        </div>
      </div>
    </div>
  );
}

export default AccessDenied;
