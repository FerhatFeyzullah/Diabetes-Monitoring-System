import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  bsLoading: false,
  bloodSugar: {},
  bloodSugarArchive: [],
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
export const GetBS_Filtered = createAsyncThunk("getbsfilter", async (data) => {
  var response = await axios.get(
    "BloodSugars/GetBS_ByPatientAndGroupedByFilteredDate",
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
export const GetBS_UnFiltered = createAsyncThunk(
  "getbsunfilter",
  async (patientId) => {
    var response = await axios.get(
      "BloodSugars/GetBS_ByPatientAndGroupedByDate",
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
        console.log("kan sekerleri geldi", state.bloodSugar);
      })
      .addCase(GetBloodSugar.rejected, (state) => {
        state.bsLoading = true;
      })
      .addCase(GetBS_Filtered.fulfilled, (state, action) => {
        state.bloodSugarArchive = action.payload;
      })
      .addCase(GetBS_UnFiltered.fulfilled, (state, action) => {
        state.bloodSugarArchive = action.payload;
      });
  },
});

export default bloodSugarSlice.reducer;
