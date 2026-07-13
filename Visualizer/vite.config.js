import { readFileSync, copyFileSync, existsSync } from 'node:fs'
import path from 'node:path'
import { fileURLToPath } from 'node:url'
import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

const __dirname = path.dirname(fileURLToPath(import.meta.url))
const mappingPath = path.resolve(__dirname, '../mapping.json')

function mappingPlugin() {
  return {
    name: 'mapping-json',
    configureServer(server) {
      server.middlewares.use('/mapping.json', (_req, res) => {
        res.setHeader('Content-Type', 'application/json')
        res.end(readFileSync(mappingPath))
      })
    },
    closeBundle() {
      if (existsSync(mappingPath)) {
        copyFileSync(mappingPath, path.resolve(__dirname, 'dist/mapping.json'))
      }
    },
  }
}

export default defineConfig({
  plugins: [vue(), mappingPlugin()],
  resolve: {
    alias: {
      '@': path.resolve(__dirname, 'src'),
    },
  },
})
