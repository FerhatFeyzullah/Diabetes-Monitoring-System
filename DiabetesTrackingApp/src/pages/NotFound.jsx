import { Button } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";

function NotFound() {
  const navigate = useNavigate();
  return (
    <div className="not-found-main-div">
      <div className="flex-column">
        <div style={{ marginTop: "15px" }}>
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

export default NotFound;
