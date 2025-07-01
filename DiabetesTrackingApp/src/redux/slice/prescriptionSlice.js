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

export const UpdatePrescription = createAsyncThunk("updateP", async (data) => {
  await axios.put("Prescriptions/UpdatePrescription", data);
  var response = await axios.get(
    "Prescriptions/GetPrescriptionByPatientAndDateDaily",
    {
      params: {
        PatientId: data.patientId,
      },
    }
  );
  return response.data;
});

export const prescriptionSlice = createSlice({
  name: "prescription",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      //Get
      .addCase(GetPrescription.pending, (state) => {
        state.pLoading = true;
      })
      .addCase(GetPrescription.fulfilled, (state, action) => {
        state.pLoading = false;
        state.prescription = action.payload;
      })
      .addCase(GetPrescription.rejected, (state) => {
        state.pLoading = true;
      })

      //Update
      .addCase(UpdatePrescription.pending, (state) => {
        state.pLoading = false;
      })
      .addCase(UpdatePrescription.fulfilled, (state, action) => {
        state.pLoading = false;
        state.prescription = action.payload;
      })
      .addCase(UpdatePrescription.rejected, (state) => {
        state.pLoading = false;
      });
  },
});

//export const {} = prescriptionSlice.actions;
export default prescriptionSlice.reducer;
