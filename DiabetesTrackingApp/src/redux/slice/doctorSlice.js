import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  doctorId: 0,
  loading: false,
  patients: [],
  newPatientDialog: false,
  newPatientResponse: "",
  succesAlert: false,
  mistakeAlert: false,
};

export const GetPatientsForDoctor = createAsyncThunk(
  "GetPatients",
  async (doctorId) => {
    var response = await axios.get("Users/GetPatientsForDoctor", {
      params: {
        DoctorId: doctorId,
      },
    });
    return response.data;
  }
);
export const CreatePatient = createAsyncThunk("newPatient", async (data) => {
  var response = await axios.post("Users/CreatePatient", data);
  return response.data;
});

export const doctorSlice = createSlice({
  name: "doctor",
  initialState,
  reducers: {
    setDoctorId: (state, action) => {
      state.doctorId = action.payload;
    },
    SetNewPatientDialogTrue: (state) => {
      state.newPatientDialog = true;
    },
    SetNewPatientDialogFalse: (state) => {
      state.newPatientDialog = false;
    },
    SuccesAlertChange: (state) => {
      state.succesAlert = false;
    },
    MistakeAlertChange: (state) => {
      state.mistakeAlert = false;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(GetPatientsForDoctor.pending, (state) => {
        state.loading = true;
      })
      .addCase(GetPatientsForDoctor.fulfilled, (state, action) => {
        state.loading = false;
        state.patients = action.payload;
      })
      .addCase(GetPatientsForDoctor.rejected, (state, action) => {
        state.loading = false;
        console.log(action.error.message);
      })

      //CreatePatient
      .addCase(CreatePatient.pending, (state) => {
        state.loading = true;
      })
      .addCase(CreatePatient.fulfilled, (state, action) => {
        state.loading = false;

        if (action.payload == "") {
          state.newPatientResponse =
            "Yeni hasta kaydı başarıyla tamamlandı. Bilgiler hastanın mail adresine gönderildi.";
          state.succesAlert = true;
          state.mistakeAlert = false;
        } else {
          state.newPatientResponse = action.payload;
          state.succesAlert = false;
          state.mistakeAlert = true;
        }
      })
      .addCase(CreatePatient.rejected, (state) => {
        state.loading = false;
        state.succesAlert = false;
        state.mistakeAlert = true;
        state.newPatientResponse = "Sunucu Tarafında Bir Hata Oluştu";
      });
  },
});

export const {
  setDoctorId,
  SetNewPatientDialogTrue,
  SetNewPatientDialogFalse,
  SuccesAlertChange,
  MistakeAlertChange,
} = doctorSlice.actions;
export default doctorSlice.reducer;
