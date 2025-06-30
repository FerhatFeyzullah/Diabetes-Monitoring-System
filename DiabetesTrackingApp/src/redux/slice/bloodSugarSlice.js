import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  bsLoading: false,
  bloodSugar: {},
};

export const GetBloodSugar = createAsyncThunk(
  "getBsDaily",
  async (patientId) => {
    const response = await axios.get(
      "BloodSugars/GetBS_ByPatientAndGroupedByDateDaily",
      {
        params: {
          PatientId: patientId,
        },
      }
    );
    return response.data;
  }
);

export const bloodSugarSlice = createSlice({
  name: "bloodSugar",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(GetBloodSugar.pending, (state) => {
        state.bsLoading = true;
      })
      .addCase(GetBloodSugar.fulfilled, (state, action) => {
        state.bsLoading = false;
        state.bloodSugar = action.payload;
      })
      .addCase(GetBloodSugar.rejected, (state) => {
        state.bsLoading = false;
      });
  },
});

//export const {} = bloodSugarSlice.actions;
export default bloodSugarSlice.reducer;
