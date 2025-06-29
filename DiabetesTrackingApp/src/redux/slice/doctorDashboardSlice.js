import { createSlice, createAsyncThunk, isPending } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  bsLoading: false,
  iLoading: false,
  dsLoading: false,
  pLoading: false,
  bloodSugar: [],
  dailyStatus: {},
  insulin: [],
  prescription: {},
};

export const GetBloodSugar = createAsyncThunk(
  "getBsDaily",
  async (patientId) => {
    try {
      const response = await axios.get(
        "BloodSugars/GetBS_ByPatientAndGroupedByDate",
        {
          params: {
            PatientId: patientId,
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error("Kan şekeri verisi alınamadı:", error);
    }
  }
);
export const GetInsulin = createAsyncThunk(
  "getInsulinDaily",
  async (patientId) => {
    var response = await axios.get(
      "Insulins/GetInsulinByPatientAndGroupedByDate",
      {
        params: {
          PatientId: patientId,
        },
      }
    );
    return response.data;
  }
);
export const GetDailyStatus = createAsyncThunk(
  "getDsDaily",
  async (patientId) => {
    var response = await axios.get("DailyStatuses/GetDS_ByPatientAndDate", {
      params: {
        PatientId: patientId,
      },
    });
    return response.data;
  }
);
export const GetPrescription = createAsyncThunk(
  "getPrescriptionDaily",
  async (patientId) => {
    var response = await axios.get(
      "Prescriptions/GetPrescriptionByPatientAndDate",
      {
        params: {
          PatientId: patientId,
        },
      }
    );
    return response.data;
  }
);

export const doctorDashboardSlice = createSlice({
  name: "doctorDashboard",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    //BloodSugar
    builder
      .addCase(GetBloodSugar.pending, (state) => {
        state.bsLoading = true;
      })
      .addCase(GetBloodSugar.fulfilled, (state, action) => {
        state.bsLoading = false;
        state.bloodSugar = action.payload;
      })
      .addCase(GetBloodSugar.rejected, (state) => {
        state.bsLoading = false;
      })

      .addCase(GetInsulin.pending, (state) => {
        state.iLoading = true;
      })
      .addCase(GetInsulin.fulfilled, (state, action) => {
        state.iLoading = false;
        state.insulin = action.payload;
      })
      .addCase(GetInsulin.rejected, (state) => {
        state.iLoading = false;
      })

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

      .addCase(GetPrescription.pending, (state) => {
        state.pLoading = true;
      })
      .addCase(GetPrescription.fulfilled, (state, action) => {
        state.pLoading = false;
        state.prescription = action.payload;
      })
      .addCase(GetPrescription.rejected, (state) => {
        state.pLoading = false;
      });
  },
});

export const {} = doctorDashboardSlice.actions;
export default doctorDashboardSlice.reducer;
