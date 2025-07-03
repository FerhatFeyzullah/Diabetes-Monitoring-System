import React from "react";
import Box from "@mui/material/Box";
import Stepper from "@mui/material/Stepper";
import Step from "@mui/material/Step";
import StepLabel from "@mui/material/StepLabel";
import { useSelector } from "react-redux";

function StepByStep() {
  const { stepCount } = useSelector((store) => store.forgotPassword);
  const steps = [
    "Kayıt Yaptığınız Email Hesabını Girin",
    "Doğrulama Kodunu Girin",
    "Yeni Şifrenizi Girin",
  ];
  return (
    <Box sx={{ width: "50%" }}>
      <Stepper activeStep={stepCount} alternativeLabel>
        {steps.map((label) => (
          <Step key={label}>
            <StepLabel>{label}</StepLabel>
          </Step>
        ))}
      </Stepper>
    </Box>
  );
}

export default StepByStep;
