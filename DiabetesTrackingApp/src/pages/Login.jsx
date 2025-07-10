import React from "react";
import LoginNavbar from "../components/Login/LoginNavbar";
import LoginCard from "../components/Login/LoginCard";
import "../css/Login.css";
import Loading from "../components/Loading";
import { useDispatch, useSelector } from "react-redux";
import MistakeAlert from "../components/Alerts/MistakeAlert";
import { LoginAlertChange } from "../redux/slice/authSlice";

function Login() {
  const { loading, loginAlert, errorMessage } = useSelector(
    (Store) => Store.auth
  );

  const dispatch = useDispatch();
  const closeAlert = () => {
    dispatch(LoginAlertChange());
  };

  return (
    <div className="login-background">
      <LoginNavbar />

      <div className="login-card">
        <LoginCard />
      </div>
      <Loading status={loading} />
      <MistakeAlert
        status={loginAlert}
        message={errorMessage}
        closer={closeAlert}
      />
    </div>
  );
}

export default Login;
