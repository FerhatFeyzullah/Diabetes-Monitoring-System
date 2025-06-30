import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  pLoading: false,
  prescription: {},
};

export const GetPrescription = createAsyncThunk(
  "getPrescriptionDaily",
  async (patientId) => {
    var response = await axios.get(
      "Prescriptions/GetPrescriptionByPatientAndDateDaily",
      {
        params: {
          PatientId: patientId,
        },
      }
    );
    return response.data;
  }
);

export const prescriptionSlice = createSlice({
  name: "prescription",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(GetPrescription.pending, (state) => {
        state.pLoading = true;
      })
      .addCase(GetPrescription.fulfilled, (state, action) => {
        state.pLoading = false;
        state.prescription = action.payload;
      })
      .addCase(GetPrescription.rejected, (state) => {
        state.pLoading = false;
      });
  },
});

//export const {} = prescriptionSlice.actions;
export default prescriptionSlice.reducer;
