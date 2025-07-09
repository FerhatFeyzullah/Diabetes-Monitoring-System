import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  accountDrawer: false,
  AppUser: JSON.parse(localStorage.getItem("AppUser")) || {},
  responseMessage: "",
  mistakeAlert: false,
  successAlert: false,
  loading: false,
  reviewPhotoDialog: false,
};

export const UploadPP = createAsyncThunk("updatepp", async (data) => {
  var response = await axios.put("Users/UploadProfilePhoto", data);
  return response.data;
});

export const RemovePP = createAsyncThunk("removepp", async (id) => {
  var response = await axios.put("Users/RemoveProfilePhoto/" + id);
  return response.data;
});
export const GetAppUser = createAsyncThunk("getUser", async (id) => {
  var response = await axios.get("Users/GetUser", {
    params: {
      AppUserId: id,
    },
  });
  return response.data;
});

export const ChangePassword = createAsyncThunk("changepass", async (data) => {
  var response = await axios.post("Users/ChangePassword", data);
  return response.data;
});

export const accountSlice = createSlice({
  name: "account",
  initialState,
  reducers: {
    SetAccountDrawerFalse: (state) => {
      state.accountDrawer = false;
    },
    SetAccountDrawerTrue: (state) => {
      state.accountDrawer = true;
    },
    SetMistakeAlertFalse: (state) => {
      state.mistakeAlert = false;
    },
    SetSuccessAlertFalse: (state) => {
      state.successAlert = false;
    },
    SetReviewPhotoDialogTrue: (state) => {
      state.reviewPhotoDialog = true;
    },
    SetReviewPhotoDialogFalse: (state) => {
      state.reviewPhotoDialog = false;
    },
  },
  extraReducers: (builder) => {
    builder
      //Upload
      .addCase(UploadPP.fulfilled, (state, action) => {
        state.AppUser = action.payload;
        localStorage.setItem("AppUser", JSON.stringify(action.payload));
      })
      .addCase(UploadPP.rejected, () => {
        console.log("PP Basarisiz");
      })
      //Remove
      .addCase(RemovePP.fulfilled, (state, action) => {
        state.AppUser = action.payload;
        localStorage.setItem("AppUser", JSON.stringify(action.payload));
      })
      .addCase(RemovePP.rejected, () => {
        console.log("PP Remove Basarisiz");
      })

      //GetAppUser
      .addCase(GetAppUser.fulfilled, (state, action) => {
        state.AppUser = action.payload;
        localStorage.setItem("AppUser", JSON.stringify(action.payload));
        console.log("GetUser Basarili");
      })
      .addCase(GetAppUser.rejected, () => {
        console.log("GetUser Basarisiz");
      })

      //ChangePassword
      .addCase(ChangePassword.pending, (state, action) => {
        state.loading = true;
      })
      .addCase(ChangePassword.fulfilled, (state, action) => {
        state.loading = false;
        if (action.payload == "") {
          state.accountDrawer = false;
          state.successAlert = true;
          state.responseMessage = "Şifre başarıyla değiştirildi";
        } else {
          state.mistakeAlert = true;
          state.responseMessage = action.payload;
        }
      })
      .addCase(ChangePassword.rejected, (state) => {
        state.loading = false;
        state.responseMessage = "Sunucu Tarafında Bir Hata Oluştu";
        state.accountDrawer = false;
        state.mistakeAlert = true;
      });
  },
});

export const {
  SetAccountDrawerFalse,
  SetAccountDrawerTrue,
  SetMistakeAlertFalse,
  SetSuccessAlertFalse,
  SetReviewPhotoDialogTrue,
  SetReviewPhotoDialogFalse,
} = accountSlice.actions;
export default accountSlice.reducer;
