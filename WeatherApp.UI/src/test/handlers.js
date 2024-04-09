import { error } from "console";
import { rest } from "msw";

const loginSuccess = {
  "user": {
    "id": "id",
    "userName": "SomeUser",
    "role": "User",
    "activityLevel": 0,
    "bodyTemp": -5
  },
  "token": "someTokenString",
}
const loginError = {
  "title": "One or more validation errors occurred",
  "status": 400,
  "errors": {
    "Password": [
      "Password is required"
    ],
    "UserName": [
      "User Name is required"
    ]
  },
}

export const handlers = [
  rest.get("http://localhost:5000/api/v1/Clothes/GetByCoords", (req, res, ctx) => {
    return res(
      ctx.status(200),
      ctx.json({
        "gloves": null,
        "hat": null,
        "overview": "Fake City USA Looks Nice Today",
        "bottomLayer": "Pants",
        "topLayers": ["Long Sleeve T-Shirt", "T-Shirt"]
      }),
    )
  }),
  rest.post("http://localhost:5000/api/v1/Login", async (req, res, ctx) => {
    const userName = req.body.userName;
    const password = req.body.password;
    if (userName && password) {
      return res(ctx.json({ loginSuccess }));
    }
    else {
      return res(
        ctx.status(400),
        ctx.json({
          loginError
        }),
      )
    }
  }),
];
