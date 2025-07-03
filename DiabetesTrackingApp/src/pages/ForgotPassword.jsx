import React from "react";
import LoginNavbar from "../components/Login/LoginNavbar";
import StepByStep from "../components/StepByStep";
import EmailCard from "../components/ForgotPassword/EmailCard";
import VerifyCodeCard from "../components/ForgotPassword/VerifyCodeCard";
import { useSelector } from "react-redux";

function ForgotPassword() {
  const { cardCount } = useSelector((store) => store.forgotPassword);
  return (
    <>
      <LoginNavbar />

      <div className="flex-column" style={{ height: "150px" }}>
        <StepByStep />
      </div>
      {cardCount === 1 && (
        <div
          className="flex-column"
          style={{ height: "150px", marginTop: "130px" }}
        >
          <EmailCard />
        </div>
      )}
      {cardCount === 2 && (
        <div
          className="flex-column"
          style={{ height: "150px", marginTop: "130px" }}
        >
          <VerifyCodeCard />
        </div>
      )}
    </>
  );
}

export default ForgotPassword;
