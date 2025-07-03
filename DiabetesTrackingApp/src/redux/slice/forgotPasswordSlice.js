import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  cardCount: 1,
  stepCount: 0,
  recoveryEmail: "",
  errorMessage: "",
  rejectedAlert: false,
};

export const SendResetCode = createAsyncThunk("resetCode", async (data) => {
  var response = await axios.post("Users/SendResetCode", data);
  return response.data;
});
export const SendResetCodeAgain = createAsyncThunk(
  "sendAgain",
  async (data) => {
    await axios.post("Users/SendResetCode", data);
  }
);
export const VerifyCode = createAsyncThunk("verifyCode", async (data) => {
  var response = await axios.post("Users/VerifyResetCode", data);
  return response.data;
});

export const forgotPasswordSlice = createSlice({
  name: "forgotPassword",
  initialState,
  reducers: {
    IncrementCardCount: (state) => {
      state.cardCount += 1;
    },
    DecrementCardCount: (state) => {
      state.cardCount -= 1;
    },
    IncrementStepCount: (state) => {
      state.stepCount += 1;
    },
    DecrementStepCount: (state) => {
      state.stepCount -= 1;
    },
    SetRecoveryEmail: (state, action) => {
      state.recoveryEmail = action.payload;
    },
    FP_RejectedAlertChange: (state) => {
      state.rejectedAlert = false;
    },
  },
  extraReducers: (builder) => {
    builder
      //SendResetCode
      .addCase(SendResetCode.fulfilled, (state, action) => {
        if (action.payload !== "") {
          state.rejectedAlert = true;
          state.errorMessage = action.payload;
        } else {
          state.errorMessage = "";
          state.cardCount += 1;
          state.stepCount += 1;
        }
      })
      .addCase(SendResetCode.rejected, (state) => {
        state.errorMessage = "Sunucu Tarafında Bir Hata Oluştu.";
        state.rejectedAlert = true;
      })

      //VerifyCode
      .addCase(VerifyCode.fulfilled, (state, action) => {
        if (action.payload == false) {
          state.rejectedAlert = true;
          state.errorMessage = "Kod Doğrulanamadı";
        } else {
          state.errorMessage = "";
          state.cardCount += 1;
          state.stepCount += 1;
        }
      })
      .addCase(VerifyCode.rejected, (state) => {
        state.errorMessage = "Sunucu Tarafında Bir Hata Oluştu.";
        state.rejectedAlert = true;
      });
  },
});

export const {
  IncrementCardCount,
  DecrementCardCount,
  IncrementStepCount,
  DecrementStepCount,
  SetRecoveryEmail,
  FP_RejectedAlertChange,
} = forgotPasswordSlice.actions;
export default forgotPasswordSlice.reducer;
