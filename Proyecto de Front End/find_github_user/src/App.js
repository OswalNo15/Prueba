import React, { useState } from "react";
import "./css/site.css";
import "./css/all.min.css";
import { GithubSearch } from "./Api/QueryGithub";

function App() {
  const [RetonorValor, setRetonorValor] = useState(null);
  const [valueText, setvalueText] = useState("");
  const ClickSearch = () => {
    if (valueText !== null && valueText !== "") {
      GithubSearch(valueText, setRetonorValor);
    } else {
      setRetonorValor(null);
    }
  };

  return (
    <>
      <div className="finder">
        <h1>Find GitHub User</h1>
        <div className="pseudo-search">
          <input
            type="text"
            maxLength={50}
            onChange={(e) => setvalueText(e.target.value)}
          />
          <i>
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="16"
              height="16"
              viewBox="0 0 16 16"
            >
              <path
                fillRule="evenodd"
                clipRule="evenodd"
                d="M7.976 0C3.565 0 0 3.592 0 8.036a8.027 8.027 0 0 0 5.453 7.623c0.396 0.08 0.541 -0.173 0.541 -0.385 0 -0.187 -0.013 -0.825 -0.013 -1.491 -2.219 0.479 -2.681 -0.957 -2.681 -0.957 -0.356 -0.931 -0.885 -1.171 -0.885 -1.171 -0.727 -0.492 0.053 -0.492 0.053 -0.492 0.805 0.053 1.228 0.825 1.228 0.825 0.713 1.224 1.861 0.879 2.324 0.665 0.065 -0.519 0.277 -0.879 0.501 -1.077 -1.769 -0.187 -3.632 -0.879 -3.632 -3.964 0 -0.879 0.317 -1.596 0.819 -2.155 -0.079 -0.2 -0.356 -1.024 0.08 -2.128 0 0 0.673 -0.213 2.192 0.825a7.668 7.668 0 0 1 1.995 -0.267c0.673 0 1.36 0.093 1.993 0.267 1.519 -1.037 2.192 -0.825 2.192 -0.825 0.436 1.104 0.159 1.929 0.079 2.128 0.515 0.559 0.819 1.277 0.819 2.155 0 3.087 -1.861 3.765 -3.645 3.964 0.291 0.253 0.541 0.732 0.541 1.489 0 1.077 -0.013 1.943 -0.013 2.208 0 0.213 0.145 0.465 0.541 0.385a8.027 8.027 0 0 0 5.453 -7.623C15.952 3.592 12.373 0 7.976 0z"
                fill="#00000"
              />
            </svg>
          </i>{" "}
          <button
            type="button"
            onClick={() => {
              ClickSearch();
            }}
          >
            <i>
              <svg
                xmlns="http://www.w3.org/2000/svg"
                className="icon icon-tabler icon-tabler-search"
                width="16"
                height="16"
                viewBox="0 0 24 24"
                strokeWidth="3"
                stroke="#000000"
                fill="none"
                strokeLinecap="round"
                strokeLinejoin="round"
              >
                <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                <path d="M10 10m-7 0a7 7 0 1 0 14 0a7 7 0 1 0 -14 0" />
                <path d="M21 21l-6 -6" />
              </svg>
            </i>
          </button>
        </div>
      </div>

      {RetonorValor !== null ? (
        RetonorValor === "Not Found" ? (
          <div className="center">
            No hay usuarios que cumplan con el criterio de búsqueda
          </div>
        ) : (
          <div className="center">
            <div className="card">
              <div className="additional">
                <div className="user-card">
                  <div className="round">
                    <label className="level">{RetonorValor.login}</label>

                    <img
                      src={`${RetonorValor.avatar_url}`}
                      alt={`${RetonorValor.id}`}
                      className="points"
                      width={"100px"}
                      height={"100px"}
                    />
                    <label className="level">{RetonorValor.created_at}</label>
                  </div>
                  <div className="more-info">
                    <div className="green">
                      <h1>{RetonorValor.name}</h1>
                    </div>
                    <div className="coords">
                      <span>
                        <i>cc</i>
                        {RetonorValor.location}
                      </span>
                      <span>
                        <i>bb</i>
                        {RetonorValor.twitter_username}
                      </span>
                    </div>
                    <div className="stats">
                      <div>
                        <i>aa</i>
                        <a className="value" href={RetonorValor.blog}>
                          <span className="title infinity">
                            {RetonorValor.blog}
                          </span>
                        </a>
                      </div>
                    </div>
                    <div className="general">
                      <div className="more">respo</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        )
      ) : (
        ""
      )}
    </>
  );
}

export default App;
