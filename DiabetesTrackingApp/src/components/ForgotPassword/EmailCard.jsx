import React, { useState } from "react";
import "../../css/ForgotPassword/EmailCard.css";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { schema } from "../../schemas/FP_EmailSchema";
import { FaArrowLeft } from "react-icons/fa";
import IconButton from "@mui/material/IconButton";
import { useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import {
  FP_RejectedAlertChange,
  SendResetCode,
  SetRecoveryEmail,
} from "../../redux/slice/forgotPasswordSlice";
import MistakeAlert from "../Alerts/MistakeAlert";

function EmailCard() {
  const [email, setEmail] = useState("");
  const [errors, setErrors] = useState({});
  const { errorMessage, rejectedAlert } = useSelector(
    (store) => store.forgotPassword
  );
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const SendCode = (data) => {
    dispatch(SetRecoveryEmail(email));
    dispatch(SendResetCode(data));
  };

  const Closer = () => {
    dispatch(FP_RejectedAlertChange());
  };

  const submit = async () => {
    try {
      await schema.validate({ email }, { abortEarly: false });
      setErrors({});

      const data = {
        Email: email,
      };

      SendCode(data);
    } catch (error) {
      const errObj = {};
      error.inner.forEach((e) => {
        errObj[e.path] = e.message;
      });
      setErrors(errObj);
    }
  };

  return (
    <div>
      <div className="e-main-container flex-column">
        <div className="fp-email-head">
          <div className="flex-row fp-back-button">
            <IconButton>
              <FaArrowLeft onClick={() => navigate("/girisyap")} />
            </IconButton>
          </div>
          <div className="fp-email-title flex-column">Email Girişi</div>
        </div>

        <div>
          <p className="fp-email-description">
            Sisteme kayıt olurken kullandığınız e-posta adresini giriniz. Girmiş
            olduğunuz adres sistemde kayıtlıysa, ilgili adrese tek kullanımlık
            bir doğrulama kodu gönderilecektir.
          </p>
        </div>

        <div className="fp-input-text">
          {errors.email ? (
            <TextField
              error
              variant="outlined"
              size="medium"
              label="Email"
              helperText={errors.email}
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              fullWidth
            />
          ) : (
            <TextField
              label="Email"
              variant="outlined"
              size="medium"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              fullWidth
            />
          )}
        </div>
        <div className="fp-input-text">
          <Button variant="contained" fullWidth onClick={submit}>
            Gönder
          </Button>
        </div>
      </div>

      <MistakeAlert
        message={errorMessage}
        status={rejectedAlert}
        closer={Closer}
      />
    </div>
  );
}

export default EmailCard;
