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

  const TransFormDate = (date) => {
    let datetime = new Date(date);
    let fechaUtc = datetime.toUTCString();
    let subString = fechaUtc.substring(0, 17);
    return subString;
  };

  return (
    <>
      <main>
        {/* finder */}

        <section>
          <div className="finder">
            <div>
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
                </i>
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
          </div>
        </section>
        <section>
          {RetonorValor !== null ? (
            RetonorValor === "Not Found" ? (
              <div className="center">
                No hay usuarios que cumplan con el criterio de búsqueda
              </div>
            ) : (
              <>
                <div className="center">
                  <div className="card">
                    {/* Left sidebar */}
                    <aside className="additional">
                      <div className="user-card">
                        <div className="round">
                          <label className="level">{RetonorValor.login}</label>
                          <img
                            src={`${RetonorValor.avatar_url}`}
                            alt={`${RetonorValor.id}`}
                            width={"100px"}
                            height={"100px"}
                            className="image"
                          />

                          <label className="level">
                            {TransFormDate(RetonorValor.created_at)}
                          </label>
                        </div>
                      </div>
                    </aside>

                    {/* content */}
                    <section>
                      <h1>{RetonorValor.name}</h1>
                      {/* contacto */}
                      <div className="contact">
                        {RetonorValor.location != null ? (
                          <span>
                            <i>
                              <svg
                                width="13"
                                height="13"
                                viewBox="0 0 0.2 0.2"
                                fill="none"
                                xmlns="http://www.w3.org/2000/svg"
                              >
                                <path
                                  clipRule="evenodd"
                                  d="M.025.075v.004c0 .018.006.035.017.049L.1.2.158.128A.079.079 0 0 0 .175.079V.075a.075.075 0 0 0-.15 0ZM.1.1a.025.025 0 1 0 0-.05.025.025 0 0 0 0 .05Z"
                                  fill="#ffff"
                                  fillRule="evenodd"
                                />
                              </svg>
                            </i>{" "}
                            {`${RetonorValor.location}`}
                          </span>
                        ) : (
                          <span>
                            <i>
                              <svg
                                width="13"
                                height="13"
                                viewBox="0 0 0.2 0.2"
                                fill="none"
                                xmlns="http://www.w3.org/2000/svg"
                              >
                                <path
                                  clipRule="evenodd"
                                  d="M.025.075v.004c0 .018.006.035.017.049L.1.2.158.128A.079.079 0 0 0 .175.079V.075a.075.075 0 0 0-.15 0ZM.1.1a.025.025 0 1 0 0-.05.025.025 0 0 0 0 .05Z"
                                  fill="#ffff"
                                  fillRule="evenodd"
                                />
                              </svg>
                            </i>
                          </span>
                        )}

                        {RetonorValor.twitter_username != null ? (
                          <a
                            rel="noopener noreferrer"
                            href={`https://twitter.com/${RetonorValor.twitter_username}`}
                            target="_blank"
                          >
                            <i>
                              <svg
                                fill="#ffff"
                                width="15"
                                height="15"
                                viewBox="-0.033 -0.065 0.39 0.39"
                                xmlns="http://www.w3.org/2000/svg"
                                preserveAspectRatio="xMinYMin"
                                className="jam jam-twitter"
                              >
                                <path d="M.325.031a.135.135 0 0 1-.038.01.066.066 0 0 0 .029-.036.136.136 0 0 1-.042.016A.067.067 0 0 0 .225 0 .066.066 0 0 0 .16.081.19.19 0 0 1 .023.012a.064.064 0 0 0-.009.033.065.065 0 0 0 .03.055.067.067 0 0 1-.031-.008v.001c0 .032.023.058.053.064a.069.069 0 0 1-.018.002L.035.158a.067.067 0 0 0 .062.046.135.135 0 0 1-.083.028L-.002.231A.191.191 0 0 0 .1.261c.123 0 .19-.1.19-.187V.066A.132.132 0 0 0 .325.031z" />
                              </svg>
                            </i>
                            <span>{"@" + RetonorValor.twitter_username}</span>
                          </a>
                        ) : (
                          <button type="button">
                            <i>
                              <svg
                                fill="#ffff"
                                width="15"
                                height="15"
                                viewBox="-0.033 -0.065 0.39 0.39"
                                xmlns="http://www.w3.org/2000/svg"
                                preserveAspectRatio="xMinYMin"
                                className="jam jam-twitter"
                              >
                                <path d="M.325.031a.135.135 0 0 1-.038.01.066.066 0 0 0 .029-.036.136.136 0 0 1-.042.016A.067.067 0 0 0 .225 0 .066.066 0 0 0 .16.081.19.19 0 0 1 .023.012a.064.064 0 0 0-.009.033.065.065 0 0 0 .03.055.067.067 0 0 1-.031-.008v.001c0 .032.023.058.053.064a.069.069 0 0 1-.018.002L.035.158a.067.067 0 0 0 .062.046.135.135 0 0 1-.083.028L-.002.231A.191.191 0 0 0 .1.261c.123 0 .19-.1.19-.187V.066A.132.132 0 0 0 .325.031z" />
                              </svg>
                            </i>
                          </button>
                        )}
                      </div>

                      {/* web */}
                      <div className="blog-container">
                        <i>
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="16"
                            height="16"
                            viewBox="0 0 321.008 321.008"
                          >
                            <path
                              fill="#fff"
                              d="M304.462 150.51C269.484 64.154 186.565 8.344 93.198 8.344c-29.23 0-57.888 5.597-85.165 16.644L0 28.24l9.752 24.128 8.044-3.263c49.675-20.13 104.914-19.7 154.306 1.202 49.588 21 88.037 60.058 108.237 109.956l3.253 8.034 24.139-9.752-3.269-8.035z"
                            />
                            <path
                              fill="#fff"
                              d="M162.606 72.72C119.257 54.369 70.632 53.983 26.94 71.66l-8.044 3.253 9.779 24.128 8.033-3.263c37.279-15.099 78.714-14.794 115.754.897 37.209 15.752 66.063 45.052 81.227 82.494l3.253 8.044 24.1-9.758-3.253-8.044c-17.774-43.883-51.578-78.22-95.183-96.691z"
                            />
                            <path
                              fill="#fff"
                              d="M93.318 111.539c-15.98 0-31.634 3.057-46.542 9.094l-8.039 3.253 9.752 24.128 8.039-3.263c11.803-4.775 24.188-7.196 36.822-7.196 40.369 0 76.229 24.128 91.349 61.467l3.258 8.044 24.117-9.774-3.269-8.034c-19.123-47.217-64.447-77.719-115.487-77.719z"
                            />
                          </svg>
                        </i>
                        &nbsp;
                        <a
                          rel="noopener noreferrer"
                          target="_blank"
                          href={RetonorValor.blog}
                        >
                          {RetonorValor.blog}
                        </a>
                      </div>

                      <div className="stats">
                        {/* card */}
                        <div className="stats-item">
                          <label className="title">Repos</label>
                          <i>
                            <svg
                              width="40"
                              height="40"
                              viewBox="0 0 1 1"
                              xmlns="http://www.w3.org/2000/svg"
                              fill="#ffff"
                            >
                              <path d="M.875.25a.125.125 0 1 0-.154.121v.067a.03.03 0 0 1-.017.028L.531.555.359.468a.031.031 0 0 1-.018-.03V.371a.125.125 0 1 0-.063 0v.067a.094.094 0 0 0 .051.084L.5.609v.083a.125.125 0 1 0 .063 0V.609L.732.524a.093.093 0 0 0 .05-.086V.37A.125.125 0 0 0 .875.25zM.25.25a.063.063 0 1 1 .125 0 .063.063 0 0 1-.125 0zm.342.563a.063.063 0 1 1-.125 0 .063.063 0 0 1 .125 0zm.158-.5a.063.063 0 1 1 0-.125.063.063 0 0 1 0 .125z" />
                            </svg>
                          </i>
                          <label className="title">
                            {RetonorValor.public_repos}
                          </label>
                        </div>
                        {/* card */}
                        <div className="stats-item">
                          <label className="title">followers</label>

                          <i>
                            <svg
                              fill="#fff"
                              width="40"
                              height="40"
                              viewBox="0 0 1.2 1.2"
                              version="1.2"
                              baseProfile="tiny"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path d="M.6.7A.25.25 0 1 0 .423.627.249.249 0 0 0 .6.7zm.4.05a.125.125 0 0 0 .125-.125.122.122 0 0 0-.037-.088A.125.125 0 0 0 1 .5a.125.125 0 0 0-.125.125A.125.125 0 0 0 1 .75zm0 .029a.208.208 0 0 0-.146.048A.406.406 0 0 0 .6.75C.487.75.4.782.345.828A.21.21 0 0 0 .2.78C.091.78.025.835.025.889c0 .027.066.055.175.055.03 0 .057-.003.081-.007L.279.951c0 .05.12.1.321.1.188 0 .321-.05.321-.1L.92.938c.023.004.05.006.08.006.103 0 .175-.027.175-.055C1.175.834 1.106.78 1 .78zM.2.75A.122.122 0 0 0 .288.713.125.125 0 0 0 .325.625.125.125 0 0 0 .2.5a.125.125 0 0 0-.125.125A.125.125 0 0 0 .2.75z" />
                            </svg>
                          </i>

                          <label className="title">
                            {RetonorValor.followers}
                          </label>
                        </div>

                        {/* card */}
                        <div className="stats-item">
                          <label className="title">following</label>

                          <i>
                            <svg
                              fill="#ffff"
                              width="40"
                              height="40"
                              viewBox="0 0 96 96"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                d="M36.769 16.805c10.912 0 19.799 8.881 19.799 19.799v5.657c0 6.098-2.828 11.489-7.178 15.126 4.707.696 9.368 1.748 13.916 3.23 6.121 1.991 10.233 7.784 10.233 14.408v10.018l-1.341.832c-7.422 4.616-19.601 10.126-35.429 10.126-8.74 0-21.988-1.759-35.434-10.126L0 85.043v-9.47c0-7.031 4.463-13.152 11.099-15.24a85.744 85.744 0 0 1 13.016-2.975c-4.327-3.637-7.145-9.017-7.145-15.098v-5.656c0-10.918 8.881-19.799 19.799-19.799ZM59.17 0c10.912 0 19.799 8.881 19.799 19.799v5.657c0 6.098-2.828 11.495-7.178 15.126 4.707.696 9.362 1.754 13.916 3.23 6.121 2.003 10.233 7.79 10.233 14.414v10.018l-1.335.832c-3.881 2.416-9.091 5.052-15.409 7.037v-1.086c0-9.085-5.679-17.038-14.136-19.788a86.007 86.007 0 0 0-5.578-1.612 24.892 24.892 0 0 0 2.744-11.364v-5.658c0-12.524-9.102-22.899-21.021-25.009C44.338 4.774 51.183 0 59.17 0Z"
                                fill-rule="evenodd"
                              />
                            </svg>
                          </i>

                          <label className="title">
                            {RetonorValor.following}
                          </label>
                        </div>
                      </div>
                    </section>
                  </div>
                </div>
              </>
            )
          ) : (
            ""
          )}
        </section>
      </main>
    </>
  );
}

export default App;
