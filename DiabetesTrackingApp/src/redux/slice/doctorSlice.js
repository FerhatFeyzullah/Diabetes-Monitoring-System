import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  doctorId: 0,
  loading: false,
  patients: [],
  newPatientDialog: false,
  newPatientResponse: "",
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
        state.newPatientResponse = action.payload;
      });
  },
});

export const {
  setDoctorId,
  SetNewPatientDialogTrue,
  SetNewPatientDialogFalse,
} = doctorSlice.actions;
export default doctorSlice.reducer;
