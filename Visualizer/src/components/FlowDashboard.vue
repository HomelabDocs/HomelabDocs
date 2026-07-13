<script setup>
import { markRaw, onMounted, ref } from 'vue'
import { VueFlow } from '@vue-flow/core'
import { Background } from '@vue-flow/background'
import { Controls } from '@vue-flow/controls'
import { fetchMapping } from '../composables/useMapping.js'
import { buildGraph } from '../utils/buildGraph.js'
import EntityNode from './nodes/EntityNode.vue'

const nodeTypes = {
  device: markRaw(EntityNode),
  service: markRaw(EntityNode),
  container: markRaw(EntityNode),
}

const nodes = ref([])
const edges = ref([])
const error = ref(null)
const loading = ref(true)

onMounted(async () => {
  try {
    const devices = await fetchMapping()
    const graph = buildGraph(devices)
    nodes.value = graph.nodes
    edges.value = graph.edges
  } catch (err) {
    error.value = err instanceof Error ? err.message : 'Unknown error'
  } finally {
    loading.value = false
  }
})
</script>

<template>
  <div class="dashboard">
    <p v-if="loading" class="dashboard__status">Loading mapping.json…</p>
    <p v-else-if="error" class="dashboard__status dashboard__status--error">
      {{ error }}
    </p>

    <VueFlow
      v-else
      v-model:nodes="nodes"
      v-model:edges="edges"
      :node-types="nodeTypes"
      class="dashboard__flow"
      fit-view-on-init
      :min-zoom="0.2"
      :max-zoom="2"
    >
      <Background :gap="20" :size="1" pattern-color="#e5e7eb" />
      <Controls />
    </VueFlow>
  </div>
</template>
