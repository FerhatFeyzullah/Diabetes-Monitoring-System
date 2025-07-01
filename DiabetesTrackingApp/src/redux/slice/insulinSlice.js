import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  iLoading: false,
  insulin: {},
};

export const GetInsulin = createAsyncThunk(
  "getInsulinDaily",
  async (patientId) => {
    var response = await axios.get(
      "Insulins/GetInsulinByPatientAndGroupedByDateDaily",
      {
        params: {
          PatientId: patientId,
        },
      }
    );
    return response.data;
  }
);

export const insulinSlice = createSlice({
  name: "insulin",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(GetInsulin.pending, (state) => {
        state.iLoading = true;
      })
      .addCase(GetInsulin.fulfilled, (state, action) => {
        state.iLoading = false;
        state.insulin = action.payload;
      })
      .addCase(GetInsulin.rejected, (state) => {
        state.iLoading = true;
      });
  },
});

//export const {} = insulinSlice.actions;
export default insulinSlice.reducer;
