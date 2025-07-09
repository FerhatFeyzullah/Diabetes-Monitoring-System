import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  selectedPatientId: null,
  selectedStartDate: null,
  selectedEndDate: null,
  selectedAlertType: 0,
  filterMod: false,
};

export const archiveSlice = createSlice({
  name: "archive",
  initialState,
  reducers: {
    SetPatientId: (state, action) => {
      state.selectedPatientId = action.payload;
    },
    SetStartDate: (state, action) => {
      state.selectedStartDate = action.payload;
    },
    SetEndDate: (state, action) => {
      state.selectedEndDate = action.payload;
    },
    SetAlertType: (state, action) => {
      state.selectedAlertType = action.payload;
    },
    SetFilterModTrue: (state) => {
      state.filterMod = true;
    },
    SetFilterModFalse: (state) => {
      state.filterMod = false;
    },
  },
});

export const {
  SetPatientId,
  SetStartDate,
  SetEndDate,
  SetFilterModTrue,
  SetFilterModFalse,
  SetAlertType,
} = archiveSlice.actions;
export default archiveSlice.reducer;
