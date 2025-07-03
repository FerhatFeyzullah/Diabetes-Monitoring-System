import * as yup from "yup";

export const schema = yup.object().shape({
  code: yup
    .string()
    .required("Doğrulama kodu zorunludur.")
    .matches(/^\d{6}$/, "Kod 6 haneli sayı olmalıdır."),
});
