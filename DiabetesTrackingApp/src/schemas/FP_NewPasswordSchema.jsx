import * as yup from "yup";
export const schema = yup.object().shape({
  password: yup
    .string()
    .required("Şifre alanı zorunlu")
    .min(8, "En az 8 karakter")
    .matches(/[a-z]/, "Küçük harf içermeli")
    .matches(/[A-Z]/, "Büyük harf içermeli")
    .matches(/[0-9]/, "Rakam içermeli")
    .matches(/[@$!%*?&]/, "Özel karakter içermeli"),

  confirmPass: yup
    .string()
    .required("Şifre tekrarı zorunlu")
    .oneOf([yup.ref("password", yup.password)], "Şifreler eşleşmiyor"),
});
