import * as yup from "yup";

export const schema = yup.object().shape({
  bsValue: yup
    .number()
    .typeError("Lütfen sayısal bir değer giriniz")
    .required("Kan şekeri değeri girilmelidir")
    .moreThan(0, "Kan şekeri değeri 0'dan büyük olmalıdır"),
});
