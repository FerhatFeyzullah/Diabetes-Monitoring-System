import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  iLoading: false,
  insulin: {},
  insulinArchive: [],
};

export const GetInsulin = createAsyncThunk(
  "getInsulinDaily",
  async (patientId) => {
    var response = await axios.get(
      "Insulins/GetInsulinByPatientAndGroupedByDateDaily",
      {
        params: {
          PatientId: patientId,
        },
      }
    );
    return response.data;
  }
);
export const GetI_Filtered = createAsyncThunk("getifilter", async (data) => {
  var response = await axios.get(
    "Insulins/GetInsulinByPatientAndGroupedByFilteredDate",
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
export const GetI_UnFiltered = createAsyncThunk(
  "getiunfilter",
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
export const insulinSlice = createSlice({
  name: "insulin",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
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
      .addCase(GetI_Filtered.fulfilled, (state, action) => {
        state.insulinArchive = action.payload;
      })
      .addCase(GetI_UnFiltered.fulfilled, (state, action) => {
        state.insulinArchive = action.payload;
      });
  },
});

//export const {} = insulinSlice.actions;
export default insulinSlice.reducer;
