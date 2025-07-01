import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  dsLoading: false,
  dailyStatus: {},
};

export const GetDailyStatus = createAsyncThunk(
  "getDsDaily",
  async (patientId) => {
    var response = await axios.get(
      "DailyStatuses/GetDS_ByPatientAndDateDaily",
      {
        params: {
          PatientId: patientId,
        },
      }
    );
    return response.data;
  }
);

export const dailyStatusSlice = createSlice({
  name: "dailyStatus",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(GetDailyStatus.pending, (state) => {
        state.dsLoading = true;
      })
      .addCase(GetDailyStatus.fulfilled, (state, action) => {
        state.dsLoading = false;
        state.dailyStatus = action.payload;
      })
      .addCase(GetDailyStatus.rejected, (state) => {
        state.dsLoading = true;
      });
  },
});

//export const {} = dailyStatusSlice.actions;
export default dailyStatusSlice.reducer;
