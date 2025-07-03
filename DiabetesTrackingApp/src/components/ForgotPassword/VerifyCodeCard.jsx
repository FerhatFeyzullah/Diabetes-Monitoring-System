import React, { useEffect, useState } from "react";
import "../../css/ForgotPassword/VerifyCodeCard.css";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { schema } from "../../schemas/FP_VerifyCodeSchema";
import { FaArrowLeft } from "react-icons/fa";
import IconButton from "@mui/material/IconButton";
import { useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import {
  DecrementCardCount,
  DecrementStepCount,
  FP_RejectedAlertChange,
  SendResetCodeAgain,
  VerifyCode,
} from "../../redux/slice/forgotPasswordSlice";
import CountdownTimer from "../../hooks/CountdownTimer";
import MistakeAlert from "../Alerts/MistakeAlert";

function EmailCard() {
  const { recoveryEmail, errorMessage, rejectedAlert } = useSelector(
    (store) => store.forgotPassword
  );
  const [code, setCode] = useState("");
  const [errors, setErrors] = useState({});
  const [isExpired, setIsExpired] = useState(false);
  const [resetTimer, setResetTimer] = useState(false);
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const submit = async () => {
    try {
      await schema.validate({ code }, { abortEarly: false });
      setErrors({});
    } catch (error) {
      const errObj = {};
      error.inner.forEach((e) => {
        errObj[e.path] = e.message;
      });
      setErrors(errObj);
    }
  };

  const TurnBack = () => {
    dispatch(DecrementCardCount());
    dispatch(DecrementStepCount());
  };

  const SendAgain = (email) => {
    const data = {
      Email: email,
    };
    dispatch(SendResetCodeAgain(data));
    setResetTimer((prev) => !prev);
    setIsExpired(false);
  };

  const verify = (mail, code) => {
    const data = {
      Email: mail,
      VerifyCode: code,
    };
    dispatch(VerifyCode(data));
  };

  useEffect(() => {
    if (resetTimer) {
      setIsExpired(false);
    }
  }, [resetTimer]);

  const Closer = () => {
    dispatch(FP_RejectedAlertChange());
  };

  return (
    <div>
      <div className="vc-main-container flex-column">
        <div className="fp-code-head">
          <div className="flex-row fp-back-button">
            <IconButton>
              <FaArrowLeft onClick={TurnBack} />
            </IconButton>
          </div>
          <div className="fp-code-title flex-column">Doğrulama Kodu</div>
        </div>

        <div>
          <p className="fp-code-description">
            Lütfen size gönderilen 6 haneli doğrulama kodunu giriniz. Bu kod
            yalnızca kısa bir süre için geçerlidir. Süre dolmadan işlemi
            tamamlayınız.
          </p>
        </div>

        <div className="fp-input-text">
          {errors.email ? (
            <TextField
              error
              variant="outlined"
              size="medium"
              label="Doğrulama Kodu"
              helperText={errors.code}
              value={code}
              onChange={(e) => setCode(e.target.value)}
              fullWidth
            />
          ) : (
            <TextField
              label="Doğrulama Kodu"
              variant="outlined"
              size="medium"
              value={code}
              onChange={(e) => setCode(e.target.value)}
              fullWidth
            />
          )}
        </div>
        <div
          className="fp-timer flex-row"
          style={{
            backgroundColor: !isExpired
              ? "rgb(144, 197, 58)"
              : "rgb(197, 58, 58)",
          }}
        >
          <CountdownTimer
            durationInSeconds={120}
            onFinish={() => setIsExpired(true)}
            resetSignal={resetTimer}
          />
        </div>
        <div className="fp-input-text">
          <Button
            variant="contained"
            fullWidth
            disabled={isExpired}
            onClick={() => verify(recoveryEmail, code)}
          >
            Gönder
          </Button>
        </div>
        <div className="fp-input-link">
          <Button
            onClick={() => SendAgain(recoveryEmail)}
            variant="contained"
            color="inherit"
            size="small"
          >
            Tekrar Kod Al
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
