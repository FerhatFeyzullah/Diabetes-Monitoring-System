import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  dietDialog: false,
  exerciseDialog: false,
  bsDrawerStatus: false,
  insulinDose: null,
  checkResult: null,
};

export const CreateBloodSugar = createAsyncThunk("createbs", async (data) => {
  var response = await axios.post("BloodSugars/CreateBloodSugar", data);
  return response.data;
});

export const CheckTimePeriod = createAsyncThunk("checkTP", async (data) => {
  var response = await axios.get("BloodSugars/GetBS_TimePeriodCheck", {
    params: {
      PatientId: data.patientId,
      TimePeriod: data.timePeriod,
    },
  });
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
  },
  extraReducers: (builder) => {
    builder

      //CreateBloodSugar
      .addCase(CreateBloodSugar.fulfilled, (state, action) => {
        state.insulinDose = action.payload;
        state.bsDrawerStatus = false;
      })
      .addCase(CreateBloodSugar.rejected, () => {
        console.log("basarisiz");
      })

      //CheckTimePeriod
      .addCase(CheckTimePeriod.fulfilled, (state, action) => {
        state.checkResult = action.payload;
      })
      .addCase(CheckTimePeriod.rejected, () => {
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
} = patientSlice.actions;
export default patientSlice.reducer;
