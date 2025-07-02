import * as yup from "yup";

export const schema = yup.object().shape({
  firstName: yup.string().required("İsim Giriniz."),

  lastName: yup.string().required("Soyisim Giriniz."),

  tc: yup
    .string()
    .required("TC Kimlik Numarası zorunlu")
    .length(11, "TC Kimlik Numarası 11 haneli olmalı"),

  email: yup
    .string()
    .email("Geçerli email adresi giriniz")
    .required("Email adresi zorunlu")
    .matches(/[a-z]/, "Küçük harf içermeli"),

  birthDate: yup.mixed().required("Doğum Tarihi Zorunlu"),
  gender: yup.number().required("Cinsiyet seçimi zorunludur"),
});
