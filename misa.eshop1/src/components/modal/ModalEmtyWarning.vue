<template>
  <transition name="component-fade" mode="out-in" >
    <div class="warning-container"   >
      <div class="warning-icon" @mouseover="showBubble" @mouseleave="hideBubble" ></div>
      <div class="warning-bubble" v-show="visible1">
        <div class="talktext">
          <p>{{ warningText }}</p>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  props: {
    storeCodeValidate:String
  },
  //props: ["color", "validate"],
  data() {
    return {
      visible: false,
      debounce: null,
      visible1:false,
      warningText: "",
    };
  },

  methods: {
    show()
    {

    },
    hide()
    {
      this.visible = false
    },

    showBubble(event){

            // clientX/Y gives the coordinates relative to the viewport in CSS pixels.
            var ele = document.getElementsByClassName("warning-icon")
            var distanceX = ele[0].offsetParent.offsetParent.offsetLeft + ele[0].offsetParent.offsetLeft
            var distanceY = ele[0].offsetParent.offsetParent.offsetTop + ele[0].offsetParent.offsetTop

if(event.clientX >= distanceX 
&& event.clientX <= distanceX + 24 
 && event.clientY >= distanceY+14 
 && event.clientY <= distanceY+35 
 && this.storeCodeValidate != "")
{ 
this.warningText = this.storeCodeValidate
}
 else this.warningText = "Trường này không được bỏ trống"
        this.visible1 = true




      //       // pageX/Y gives the coordinates relative to the <html> element in CSS pixels.
      //       console.log(event.pageX);
      //       console.log(event.pageY);

      //       // screenX/Y gives the coordinates relative to the screen in device pixels.
      //       console.log(event.screenX);
      //       console.log(event.screenY);

      //   if( )
      // {
        
      // }
     
  
    },

    hideBubble(){
        this.visible1 = false
    },

  },

  updated(){
    this.show()
  }
};
</script>

<style scoped>
.warning-container {
  height: 40px;
  width: 265px;
  display: flex;
  align-items: center;
  position: relative;
  margin-left: 5px;
  cursor: pointer;

}

.warning-bubble {
  width: 200px;
  background: red;
  height: 40px;
  display: flex;
  align-items: center;
  border-radius: 3px;
  position: relative;
}

.warning-bubble::after {
  content: " ";
  /* height: 16px; */
  /* width: 16px; */
  /* background: green; */
  position: absolute;
  border: 8px solid;
  left: -16px;
  border-color: transparent red transparent transparent;
}

.red {
  background-color: red;
  color: #ffffff;
}

.black {
  color: #ffffff;
}

.warning-icon {
  background-image: url(../../assets/icon/warning32.png);
  background-size: contain;
  height: 16px;
  width: 16px;
  margin-right: 5px;
  margin-top: 8px;
}

.warning-icon:hover{

}

.talk-bubble {
  display: inline-block;
  position: absolute;
  width: 200px;
  height: auto;
  min-height: 40px;
  border-radius: 4px;

  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2), 5px 5px 20px rgba(0, 0, 0, 0.18) !important;
  z-index: 99999;
}

.talk-bubble:after {
  content: " ";
  position: absolute;
  width: 0;
  height: 0;
  left: -26px;
  right: auto;
  top: 4px;
  bottom: auto;
  border: 16px solid;
  border-color: transparent red transparent transparent;
}

.talktext {
  padding: 0.6em;
}

.component-fade-enter-active {
  transition: opacity 5s;
}
.component-fade-leave-active {
  transition: opacity 0.5s;
}

.component-fade-enter {
  opacity: 0;
}

.component-fade-leave-to {
  opacity: 0;
}

</style>