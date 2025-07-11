import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  alerts: [],
  alertArchive: [],
  alertDrawer: false,
  isAlert: 0,
  alertsErrorMessage: "",
  alertsErrorAlert: false,
};

export const GetA_FilteredDate = createAsyncThunk(
  "getafilterdate",
  async (data) => {
    var response = await axios.get("Alerts/GetAlertsByPatientAndDate", {
      params: {
        PatientId: data.id,
        StartDate: data.start,
        EndDate: data.end,
      },
    });
    return response.data;
  }
);
export const GetA_FilteredType = createAsyncThunk(
  "getafiltertype",
  async (data) => {
    var response = await axios.get("Alerts/GetAlertByPatientAndAlertType", {
      params: {
        PatientId: data.id,
        AlertType: data.type,
      },
    });
    return response.data;
  }
);
export const GetA_FilteredDateAndType = createAsyncThunk(
  "getafilterdatteandatype",
  async (data) => {
    var response = await axios.get("Alerts/GetAlertsByPatientAndDateAndType", {
      params: {
        PatientId: data.id,
        StartDate: data.start,
        EndDate: data.end,
        AlertType: data.type,
      },
    });
    return response.data;
  }
);
export const GetA_UnFiltered = createAsyncThunk("getaunfilter", async (id) => {
  var response = await axios.get("Alerts/GetAlertsByPatient", {
    params: {
      PatientId: id,
    },
  });
  return response.data;
});
export const GetA_Daily = createAsyncThunk("getadaily", async (id) => {
  var response = await axios.get("Alerts/GetAlertsDaily", {
    params: {
      DoctorId: id,
    },
  });
  return response.data;
});
export const IsAlertExist = createAsyncThunk("unreadAlert", async (id) => {
  var response = await axios.get("Alerts/GetUnReadAlertsCount", {
    params: {
      DoctorId: id,
    },
  });
  return response.data;
});
export const ReadAlert = createAsyncThunk("read", async (data) => {
  var response = await axios.put("Alerts/ReadingAlert", data);
  return response.data;
});

export const alertSlice = createSlice({
  name: "alert",
  initialState,
  reducers: {
    SetAlertDrawerTrue: (state) => {
      state.alertDrawer = true;
    },
    SetAlertDrawerFalse: (state) => {
      state.alertDrawer = false;
    },
    SetAlertsErrorAlertFalse: (state) => {
      state.alertsErrorAlert = false;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(GetA_Daily.fulfilled, (state, action) => {
        state.alerts = action.payload;
      })
      .addCase(GetA_UnFiltered.fulfilled, (state, action) => {
        state.alertArchive = action.payload;
      })
      .addCase(GetA_FilteredDate.fulfilled, (state, action) => {
        state.alertArchive = action.payload;
      })
      .addCase(GetA_FilteredType.fulfilled, (state, action) => {
        state.alertArchive = action.payload;
      })
      .addCase(GetA_FilteredDateAndType.fulfilled, (state, action) => {
        state.alertArchive = action.payload;
      })

      //IsAlertExist
      .addCase(IsAlertExist.fulfilled, (state, action) => {
        state.isAlert = action.payload;
      })
      .addCase(IsAlertExist.rejected, (state) => {
        state.alertsErrorAlert = true;
        state.alertsErrorMessage =
          "Sunucu Tarfında Bir Hata Oluştu, Lütfen Daha Sonra Tekrar Deneyin";
      })
      .addCase(ReadAlert.fulfilled, (state, action) => {
        state.isAlert = action.payload;
        console.log("readAlert");
      })
      .addCase(ReadAlert.rejected, (state) => {
        state.alertsErrorAlert = true;
        state.alertsErrorMessage =
          "Sunucu Tarfında Bir Hata Oluştu, Lütfen Daha Sonra Tekrar Deneyin";
      });
  },
});

export const {
  SetAlertDrawerFalse,
  SetAlertDrawerTrue,
  SetAlertsErrorAlertFalse,
} = alertSlice.actions;
export default alertSlice.reducer;
