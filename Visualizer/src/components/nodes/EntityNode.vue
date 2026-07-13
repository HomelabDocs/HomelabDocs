<script setup>
import { Handle, Position } from '@vue-flow/core'

defineProps({
  data: {
    type: Object,
    required: true,
  },
  type: {
    type: String,
    default: 'default',
  },
})
</script>

<template>
  <div class="entity-node" :class="`entity-node--${type}`">
    <Handle type="target" :position="Position.Top" />
    <span class="entity-node__label">{{ data.label }}</span>
    <Handle type="source" :position="Position.Bottom" />
  </div>
</template>
