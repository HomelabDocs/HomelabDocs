const MAPPING_URL = `${import.meta.env.BASE_URL}mapping.json`

export async function fetchMapping() {
  const response = await fetch(MAPPING_URL)

  if (!response.ok) {
    throw new Error(`Failed to load mapping.json (${response.status})`)
  }

  return response.json()
}
