import axios from "axios";

export const GithubSearch = async (valor, setRetonorValor) => {
  axios
    .get(`https://api.github.com/users/${valor}`)
    .then((response) => {
      setRetonorValor(response.data);
    })
    .catch((error) => {
        setRetonorValor(error.response.data.message);
      //   setRetonorValor(error.data.message);
    });
};
