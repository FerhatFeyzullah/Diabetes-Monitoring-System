import React, { useEffect, useState } from "react";
import TextField from "@mui/material/TextField";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { schema } from "../../schemas/LoginSchema";
import { LoginPost, ReadToken } from "../../redux/slice/authSlice";
import IconButton from "@mui/material/IconButton";
import InputAdornment from "@mui/material/InputAdornment";
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import { Button, Alert } from "@mui/material";
import { setDoctorId } from "../../redux/slice/doctorSlice";

function LoginCard() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const { token, errorMessage, loginAlert } = useSelector(
    (store) => store.auth
  );
  const { userId, role } = token;

  const [tc, setTc] = useState("");
  const [password, setPassword] = useState("");
  const [errors, setErrors] = useState({});
  const [show, setShow] = useState(false);

  useEffect(() => {
    if (userId && role) {
      if (role === "Doktor") {
        navigate("/doktor/" + userId);
        dispatch(setDoctorId(userId));
        localStorage.setItem("UserId", userId);
      } else if (role === "Hasta") {
        navigate("/hasta/" + userId);
        localStorage.setItem("UserId", userId);
      } else {
        console.warn("Bilinmeyen rol:", role);
      }
    }
  }, [userId, role, navigate, dispatch]);

  const formClear = () => {
    setTc("");
    setPassword("");
  };

  const submit = async () => {
    try {
      await schema.validate({ tc, password }, { abortEarly: false });
      setErrors({});

      const loginData = {
        TC: tc,
        Password: password,
      };

      const loginResult = await dispatch(LoginPost(loginData)).unwrap();

      if (loginResult.success) {
        await dispatch(ReadToken());
        formClear();
      }
    } catch (error) {
      const errObj = {};
      if (error.inner) {
        error.inner.forEach((e) => {
          errObj[e.path] = e.message;
        });
        setErrors(errObj);
      } else {
        setErrors({ general: error.message || "Bir hata oluştu" });
      }
    }
  };

  return (
    <div className="flex-column login-card-main">
      <div className="login-card-title">Giriş Yap</div>
      <div className="flex-column">
        <div className="login-input">
          {errors.tc ? (
            <TextField
              error
              variant="standard"
              size="small"
              label="T.C. Kimlik No"
              helperText={errors.tc}
              value={tc}
              onChange={(e) => setTc(e.target.value)}
              fullWidth
              type="number"
            />
          ) : (
            <TextField
              label="T.C. Kimlik No"
              variant="standard"
              size="small"
              value={tc}
              onChange={(e) => setTc(e.target.value)}
              fullWidth
              type="number"
            />
          )}
        </div>
        <div className="login-input">
          {errors.password ? (
            <TextField
              error
              variant="standard"
              size="small"
              label="Şifre"
              helperText={errors.password}
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              fullWidth
              type={show ? "text" : "password"}
              InputProps={{
                endAdornment: (
                  <InputAdornment position="end">
                    <IconButton onClick={() => setShow(!show)} edge="end">
                      {show ? <VisibilityOff /> : <Visibility />}
                    </IconButton>
                  </InputAdornment>
                ),
              }}
            />
          ) : (
            <TextField
              label="Şifre"
              variant="standard"
              size="small"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              fullWidth
              type={show ? "text" : "password"}
              InputProps={{
                endAdornment: (
                  <InputAdornment position="end">
                    <IconButton onClick={() => setShow(!show)} edge="end">
                      {show ? <VisibilityOff /> : <Visibility />}
                    </IconButton>
                  </InputAdornment>
                ),
              }}
            />
          )}
        </div>
      </div>

      <div className="login-card-button">
        <Button
          variant="contained"
          onClick={submit}
          sx={{ textTransform: "none" }}
          fullWidth
        >
          Giriş Yap
        </Button>
      </div>
      <div className="login-card-link">
        <Button
          onClick={() => navigate("/sifremiunuttum")}
          variant="contained"
          size="small"
          color="inherit"
          sx={{ textTransform: "none" }}
        >
          Şifremi Unuttum
        </Button>
      </div>
    </div>
  );
}

export default LoginCard;
