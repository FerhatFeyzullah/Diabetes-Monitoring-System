import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  pLoading: false,
  prescription: {},
  prescriptionArchive: [],
};

export const GetPrescription = createAsyncThunk(
  "getPrescriptionDaily",
  async (patientId) => {
    var response = await axios.get(
      "Prescriptions/GetPrescriptionByPatientAndDateDaily",
      {
        params: {
          PatientId: patientId,
        },
      }
    );
    return response.data;
  }
);
export const UpdatePrescription = createAsyncThunk("updateP", async (data) => {
  await axios.put("Prescriptions/UpdatePrescription", data);
  var response = await axios.get(
    "Prescriptions/GetPrescriptionByPatientAndDateDaily",
    {
      params: {
        PatientId: data.patientId,
      },
    }
  );
  return response.data;
});
export const GetP_Filtered = createAsyncThunk("getpfilter", async (data) => {
  var response = await axios.get(
    "Prescriptions/GetPrescriptionByPatientAndFilteredDate",
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
export const GetP_UnFiltered = createAsyncThunk(
  "getpunfilter",
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

export const prescriptionSlice = createSlice({
  name: "prescription",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      //Get
      .addCase(GetPrescription.pending, (state) => {
        state.pLoading = true;
      })
      .addCase(GetPrescription.fulfilled, (state, action) => {
        state.pLoading = false;
        state.prescription = action.payload;
      })
      .addCase(GetPrescription.rejected, (state) => {
        state.pLoading = false;
      })

      //Update
      .addCase(UpdatePrescription.pending, (state) => {
        state.pLoading = true;
      })
      .addCase(UpdatePrescription.fulfilled, (state, action) => {
        state.pLoading = false;
        state.prescription = action.payload;
      })
      .addCase(UpdatePrescription.rejected, (state) => {
        state.pLoading = false;
      })

      //GetArchive
      .addCase(GetP_Filtered.fulfilled, (state, action) => {
        state.prescriptionArchive = action.payload;
      })
      .addCase(GetP_UnFiltered.fulfilled, (state, action) => {
        state.prescriptionArchive = action.payload;
      });
  },
});

//export const {} = prescriptionSlice.actions;
export default prescriptionSlice.reducer;
