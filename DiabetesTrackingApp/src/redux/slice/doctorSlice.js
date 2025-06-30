import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  doctorId: 0,
  loading: false,
  patients: [],
};

export const GetPatientsForDoctor = createAsyncThunk(
  "GetPatients",
  async (data) => {
    var response = await axios.get("Users/GetPatientsForDoctor", {
      params: {
        DoctorId: data.doctorId,
      },
    });
    return response.data;
  }
);

export const doctorSlice = createSlice({
  name: "doctor",
  initialState,
  reducers: {
    setDoctorId: (state, action) => {
      state.doctorId = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(GetPatientsForDoctor.pending, (state) => {
      state.loading = true;
    }),
      builder.addCase(GetPatientsForDoctor.fulfilled, (state, action) => {
        state.loading = false;
        state.patients = action.payload;
      }),
      builder.addCase(GetPatientsForDoctor.rejected, (state, action) => {
        state.loading = false;
        console.log(action.error.message);
      });
  },
});

export const { setDoctorId } = doctorSlice.actions;
export default doctorSlice.reducer;
