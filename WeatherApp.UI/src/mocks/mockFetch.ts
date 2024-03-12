import { Clothes } from "../models/clothes"

const clothesRepsonse: Clothes = {
  gloves: "Test Gloves",
  hat: "",
  overview: "Test Overview",
  bottomLayer: "Pants",
  topLayers: ["T-Shirt", "Jacket"]
}

const mockFetch = async () => {
  var response = new Response();
  response.json = async () => clothesRepsonse;
  return response; /*{
    ok: true,
    status: 200,
    json: async () => clothesRepsonse,
  };*/
}

export default mockFetch;