import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  dietDialog: false,
  exerciseDialog: false,
  bsDrawerStatus: false,
  insulinDose: null,
  checkResult: null,
  insulinDialog: false,
  errorMessage: "",
  mistakeAlert: false,
  loading: false,
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

export const UpdateDietOK = createAsyncThunk("updateDietok", async (data) => {
  await axios.put("DailyStatuses/UpdateDS_DietOk", data);
  console.log(data);
});

export const UpdateDietNotOK = createAsyncThunk(
  "updateDietnotok",
  async (data) => {
    await axios.put("DailyStatuses/UpdateDS_DietNotOk", data);
    console.log(data);
  }
);

export const UpdateExerciseOK = createAsyncThunk(
  "updateExerciseok",
  async (data) => {
    await axios.put("DailyStatuses/UpdateDS_ExerciseOk", data);
  }
);

export const UpdateExerciseNotOK = createAsyncThunk(
  "updateExercisenotok",
  async (data) => {
    await axios.put("DailyStatuses/UpdateDS_ExerciseNotOk", data);
  }
);

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
    SetCheckResultTrue: (state) => {
      state.checkResult = true;
    },
    SetMistakeAlertFalse: (state) => {
      state.mistakeAlert = false;
    },
    SetInsulinDialogFalse: (state) => {
      state.insulinDialog = false;
    },
  },
  extraReducers: (builder) => {
    builder

      //CreateBloodSugar

      .addCase(CreateBloodSugar.pending, (state) => {
        state.loading = true;
      })
      .addCase(CreateBloodSugar.fulfilled, (state, action) => {
        state.insulinDose = action.payload;
        state.bsDrawerStatus = false;
        state.loading = false;
        state.insulinDialog = true;
        state.errorMessage = "";
        state.mistakeAlert = false;
      })
      .addCase(CreateBloodSugar.rejected, (state) => {
        state.loading = false;
        state.errorMessage = "Sunucu Tarafında Bir Hata Oluştu";
        state.mistakeAlert = true;
      })

      //CheckTimePeriod
      .addCase(CheckTimePeriod.fulfilled, (state, action) => {
        state.checkResult = action.payload;
      })
      .addCase(CheckTimePeriod.rejected, (state) => {
        console.log("Check Time Basarisiz");
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
  SetCheckResultTrue,
  SetMistakeAlertFalse,
  SetInsulinDialogFalse,
} = patientSlice.actions;
export default patientSlice.reducer;
