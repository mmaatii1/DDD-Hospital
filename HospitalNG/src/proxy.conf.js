const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "http://localhost:57678/",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
