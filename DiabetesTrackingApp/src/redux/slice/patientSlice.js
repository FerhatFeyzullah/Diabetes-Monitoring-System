import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  dietDialog: false,
  exerciseDialog: false,
  bsDrawerStatus: false,
  insulinDose: null,
  donePeriods: [],
  currentPeriod: null,
};

export const CreateBloodSugar = createAsyncThunk("createbs", async (data) => {
  var response = await axios.post("BloodSugars/CreateBloodSugar", data);
  return response.data;
});

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
    SetCurrentPeriod: (state, action) => {
      state.currentPeriod = action.payload;
    },

    AddDonePeriods: (state, action) => {
      if (!state.donePeriods.includes(action.payload)) {
        state.donePeriods.push(action.payload);
      }
    },
    ResetDonePeriods: (state) => {
      state.donePeriods = [];
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(CreateBloodSugar.fulfilled, (state, action) => {
        state.insulinDose = action.payload;
      })
      .addCase(CreateBloodSugar.rejected, () => {
        console.log("basarisiz");
      });
  },
});

export const {
  SetDietDialogTrue,
  SetDietDialogFalse,
  SetExerciseDialogTrue,
  SetExerciseDialogFalse,
  SetBsDrawerTrue,
  SetBsDrawerFalse,
  AddDonePeriods,
  ResetDonePeriods,
  SetCurrentPeriod,
} = patientSlice.actions;
export default patientSlice.reducer;
