import React, { useEffect, useState } from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import Slide from "@mui/material/Slide";
import { useDispatch, useSelector } from "react-redux";
import {
  CreatePatient,
  GetPatientsForDoctor,
  SetNewPatientDialogFalse,
} from "../../redux/slice/doctorSlice";
import TextField from "@mui/material/TextField";
import { schema } from "../../schemas/CreatePatientSchema";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { DemoContainer } from "@mui/x-date-pickers/internals/demo";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import Radio from "@mui/material/Radio";
import RadioGroup from "@mui/material/RadioGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import dayjs from "dayjs";
import Loading from "../Loading";

const Transition = React.forwardRef(function Transition(props, ref) {
  return <Slide direction="down" ref={ref} {...props} />;
});

function NewPatientDialog({ doctorId }) {
  const { newPatientDialog, newPatientResponse, loading } = useSelector(
    (store) => store.doctor
  );
  const dispatch = useDispatch();

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [tc, setTc] = useState("");
  const [email, setEmail] = useState("");
  const [birthDate, setBirthDate] = useState(null);
  const [gender, setGender] = useState(null);
  const [errors, setErrors] = useState({});

  const handleChange = (event) => {
    setGender(event.target.value);
  };

  const CloseDialog = () => {
    dispatch(SetNewPatientDialogFalse());
    formClear();
  };

  const formClear = () => {
    setFirstName("");
    setLastName("");
    setTc("");
    setEmail("");
    setBirthDate(null);
    setGender(null);
  };

  const formattedBirthDate = dayjs(birthDate).format("YYYY-MM-DD");
  const submit = async () => {
    try {
      await schema.validate(
        { firstName, lastName, tc, email, birthDate, gender },
        { abortEarly: false }
      );
      setErrors({});

      const data = {
        FirstName: firstName,
        LastName: lastName,
        TC: tc,
        Email: email,
        BirthDate: formattedBirthDate,
        Gender: Number(gender),
        DoctorId: doctorId,
      };
      CloseDialog();
      await dispatch(CreatePatient(data));
      await dispatch(GetPatientsForDoctor(doctorId));
    } catch (error) {
      const errObj = {};
      error.inner.forEach((e) => {
        errObj[e.path] = e.message;
      });
      setErrors(errObj);
    }
  };
  useEffect(() => {
    console.log(newPatientResponse);
  }, [newPatientResponse]);

  return (
    <div>
      <Loading status={loading} />
      <Dialog
        open={newPatientDialog}
        slots={{
          transition: Transition,
        }}
        keepMounted
        onClose={CloseDialog}
      >
        <DialogTitle>{"Yeni Hasta Kaydı"}</DialogTitle>
        <DialogContent sx={{ width: "300px" }}>
          <div className="n-p-d-input" style={{ marginBottom: "7px" }}>
            {errors.firstName ? (
              <TextField
                error
                variant="standard"
                size="small"
                label="İsim"
                helperText={errors.firstName}
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
                fullWidth
                type="text"
              />
            ) : (
              <TextField
                label="İsim"
                variant="standard"
                size="small"
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
                fullWidth
                type="text"
              />
            )}
          </div>
          <div className="n-p-d-input" style={{ marginBottom: "7px" }}>
            {errors.lastName ? (
              <TextField
                error
                variant="standard"
                size="small"
                label="Soyisim"
                helperText={errors.lastName}
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
                fullWidth
                type="text"
              />
            ) : (
              <TextField
                label="Soyisim"
                variant="standard"
                size="small"
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
                fullWidth
                type="text"
              />
            )}
          </div>
          <div className="n-p-d-input" style={{ marginBottom: "7px" }}>
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
          <div className="n-p-d-input" style={{ marginBottom: "7px" }}>
            {errors.email ? (
              <TextField
                error
                variant="standard"
                size="small"
                label="Email"
                helperText={errors.email}
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                fullWidth
              />
            ) : (
              <TextField
                label="Email"
                variant="standard"
                size="small"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                fullWidth
              />
            )}
          </div>
          <div className="n-p-d-date-gender" style={{ marginBottom: "7px" }}>
            <div style={{ marginBottom: "7px" }}>
              <LocalizationProvider dateAdapter={AdapterDayjs}>
                <DemoContainer components={["DatePicker"]}>
                  {errors.birthDate ? (
                    <DatePicker
                      label="Doğum Tarihi"
                      value={birthDate}
                      onChange={(e) => setBirthDate(e)}
                      slotProps={{
                        textField: {
                          error: !!errors.birthDate,
                          helperText: errors.birthDate,
                          variant: "standard",
                          fullWidth: true,
                          size: "small",
                        },
                      }}
                    />
                  ) : (
                    <DatePicker
                      error
                      helperText={errors.birthDate}
                      label="Doğum Tarihi"
                      sx={{ width: "100%" }}
                      fullWidth
                      value={birthDate}
                      onChange={(e) => setBirthDate(e)}
                    />
                  )}
                </DemoContainer>
              </LocalizationProvider>
            </div>
            <div>
              <FormControl error={!!errors.gender}>
                <FormLabel>Cinsiyet</FormLabel>
                <RadioGroup
                  value={gender}
                  onChange={(e) => setGender(Number(e.target.value))}
                  row
                >
                  <FormControlLabel
                    value={2}
                    control={<Radio />}
                    label="Erkek"
                  />
                  <FormControlLabel
                    value={1}
                    control={<Radio />}
                    label="Kadın"
                  />
                </RadioGroup>
                {errors.gender && (
                  <p style={{ color: "red", fontSize: "14px" }}>
                    {errors.gender}
                  </p>
                )}
              </FormControl>
            </div>
          </div>
        </DialogContent>
        <DialogActions>
          <Button onClick={CloseDialog}>Vazgeç</Button>
          <Button onClick={submit}>Kaydet</Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}

export default NewPatientDialog;
