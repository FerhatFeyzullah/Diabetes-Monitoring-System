import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  cardCount: 1,
  stepCount: 0,
  recoveryEmail: "",
  errorMessage: "",
  rejectedAlert: false,
  loading: false,
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
export const ChangeForgotPassword = createAsyncThunk(
  "newpassword",
  async (data) => {
    await axios.post("Users/ChangeForgotPassword", data);
  }
);

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
      .addCase(SendResetCode.pending, (state) => {
        state.loading = true;
      })
      .addCase(SendResetCode.fulfilled, (state, action) => {
        state.loading = false;

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
        state.loading = false;
        state.errorMessage = "Sunucu Tarafında Bir Hata Oluştu.";
        state.rejectedAlert = true;
      })

      //VerifyCode
      .addCase(VerifyCode.pending, (state) => {
        state.loading = true;
      })
      .addCase(VerifyCode.fulfilled, (state, action) => {
        state.loading = false;

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
        state.loading = false;
        state.errorMessage = "Sunucu Tarafında Bir Hata Oluştu.";
        state.rejectedAlert = true;
      })

      //ChangeForgotPassword
      .addCase(ChangeForgotPassword.pending, (state) => {
        state.loading = true;
      })
      .addCase(ChangeForgotPassword.fulfilled, (state) => {
        state.loading = false;

        state.cardCount += 1;
        state.stepCount += 1;
      })
      .addCase(ChangeForgotPassword.rejected, (state) => {
        state.loading = false;
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
