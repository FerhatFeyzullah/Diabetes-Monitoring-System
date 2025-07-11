import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  dsLoading: false,
  dailyStatus: {},
  dailyStatusArchive: [],
  percentages: {},
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
export const GetDS_Filtered = createAsyncThunk("getdsfilter", async (data) => {
  var response = await axios.get(
    "DailyStatuses/GetDS_ByPatientAndFilteredDate",
    {
      params: {
        PatientId: data.patientId,
        Start: data.startDate,
        End: data.endDate,
      },
    }
  );
  return response.data;
});
export const GetDS_UnFiltered = createAsyncThunk(
  "getdsunfilter",
  async (patientId) => {
    var response = await axios.get("DailyStatuses/GetDS_ByPatientAndDate", {
      params: {
        PatientId: patientId,
      },
    });
    return response.data;
  }
);

export const GetPercentage = createAsyncThunk("percentage", async (id) => {
  var response = await axios.get("DailyStatuses/GetPercentage", {
    params: {
      PatientId: id,
    },
  });
  return response.data;
});

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
        state.dsLoading = false;
      })
      .addCase(GetDS_Filtered.fulfilled, (state, action) => {
        state.dailyStatusArchive = action.payload;
      })
      .addCase(GetDS_UnFiltered.fulfilled, (state, action) => {
        state.dailyStatusArchive = action.payload;
      })

      //GetPercentage
      .addCase(GetPercentage.fulfilled, (state, action) => {
        state.percentages = action.payload;
      })
      .addCase(GetPercentage.rejected, () => {
        console.log("percentage basarisiz");
      });
  },
});

//export const {} = dailyStatusSlice.actions;
export default dailyStatusSlice.reducer;
