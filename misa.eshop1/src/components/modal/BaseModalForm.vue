<template>
  <div>
    <div v-if="active">
      <div class="modal-background"></div>
      <slot></slot>
    </div>
  </div>
</template>

<script>
export default {
  // name:'compName',
  data() {
    return {
      active: false,
    };
  },

  methods: {
    show() {
      this.active = true;
    },

    hide() {
      this.active = false;
    },
  },
};
</script>

<style scoped>
.modal-background {
  position: fixed;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  background-color: #000000;
  opacity: 0.2;
}
</style>