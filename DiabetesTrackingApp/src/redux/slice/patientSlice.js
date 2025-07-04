import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  dietDialog: false,
  exerciseDialog: false,
  bsDrawerStatus: false,
};

export const patientSlice = createSlice({
  name: "patient",
  initialState,
  reducers: {
    SetDietDialogTrue: (state) => {
      state.dietDialog = true;
    },
    SetDietDialogFalse: (state) => {
      state.dietDialog = false;
    },
    SetExerciseDialogTrue: (state) => {
      state.exerciseDialog = true;
    },
    SetExerciseDialogFalse: (state) => {
      state.exerciseDialog = false;
    },
    SetBsDrawerTrue: (state) => {
      state.bsDrawerStatus = true;
    },
    SetBsDrawerFalse: (state) => {
      state.bsDrawerStatus = false;
    },
  },
  extraReducers: (builder) => {},
});

export const {
  SetDietDialogTrue,
  SetDietDialogFalse,
  SetExerciseDialogTrue,
  SetExerciseDialogFalse,
  SetBsDrawerTrue,
  SetBsDrawerFalse,
} = patientSlice.actions;
export default patientSlice.reducer;
